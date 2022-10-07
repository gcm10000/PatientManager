using OfficeOpenXml;
using OfficeOpenXml.Style;
using PatientManager.Application.Interfaces.XLSX;
using PatientManager.Domain.Common.Entities;
using PatientManager.Domain.Common.Exceptions;
using PatientManager.FileService.Attributes;
using PatientManager.FileService.Models;

namespace PatientManager.FileService.Services.XLSX
{
    public class XLSXWriter : IExportFileXLSX
    {
        public XLSXWriter()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public async Task<byte[]> WriteDataAsync<T>(IList<T> models)
        {
            if (!models.Any())
                throw new ListEmptyException("Não há registros a serem exportados.");

            var exportModels = GetExportModels(models).ToList();

            using var p = new ExcelPackage();
            var ws = p.Workbook.Worksheets.Add(typeof(T).Name);
            var headers = GetHeaders(GetListType(exportModels), out List<int> columnPositionNotIgnoreExports);
            for (int headerIndex = 0; headerIndex < headers.Count; headerIndex++)
            {
                ws.Cells[1, headerIndex + 1].Value = headers[headerIndex];

                ws.Cells[1, headerIndex + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[1, headerIndex + 1].Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                ws.Cells[1, headerIndex + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#ED7D31"));
                ws.Cells[1, headerIndex + 1].Style.Font.Bold = true;
            }

            for (int rowIndex = 0; rowIndex < exportModels.Count; rowIndex++)
            {
                var properties = exportModels[rowIndex].GetType().GetProperties();
                foreach (var i in columnPositionNotIgnoreExports)
                {
                    ws.Cells[rowIndex + 2, columnPositionNotIgnoreExports.IndexOf(i) + 1].Value = 
                        properties[i].GetValue(exportModels[rowIndex], null);
                }
            }

            ws.Cells.AutoFitColumns();
            MemoryStream memoryStream = new MemoryStream();
            await p.SaveAsAsync(memoryStream);
            return memoryStream.ToArray();
        }

        private static Type GetListType<T>(List<T> _)
        {
            return typeof(T);
        }

        private static object GetExportModel<T>(T model)
        {
            if (model is Patient)
            {
                var patient = model as Patient;
                var patientExportModel = new PatientExportModel(patient);
                return patientExportModel;
            }

            if (model is Attendance)
            {
                var attendance = model as Attendance;
                var patientExportModel = new AttendanceExportModel(attendance);
                return patientExportModel;
            }

            throw new ArgumentException("Exportação não configurada.", nameof(model));
        }

        private static IEnumerable<object> GetExportModels<T>(IList<T> models)
        {
            foreach (var model in models)
                yield return GetExportModel(model);
        }

        private static IList<string> GetHeaders(Type type, out List<int> columnPositionNotIgnoreExports)
        {
            List<string> headers = new();
            columnPositionNotIgnoreExports = new List<int>();

            var properties = type.GetProperties();

            for (int columnCounter = 0; columnCounter < properties.Length; columnCounter++)
            {
                columnPositionNotIgnoreExports.Add(columnCounter);

                object[] attrs = properties[columnCounter].GetCustomAttributes(true);

                var header = string.Empty;

                bool ignoreExport = false;
                foreach (object attr in attrs)
                {
                    var headerAttr = attr as HeaderAttribute;
                    var ignoreExportAttr = attr as IgnoreExportAttribute;

                    if (ignoreExportAttr != null)
                    {
                        ignoreExport = true;
                        columnPositionNotIgnoreExports.Remove(columnCounter);
                    }
                    if (headerAttr != null)
                    {
                        header = headerAttr.Name;
                    }
                }

                if (!ignoreExport)
                {
                    if (header == string.Empty)
                        header = properties[columnCounter].Name;
                    headers.Add(header);
                }
            }
            return headers;
        }
    }
}
