using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using PTPMQL_MVC.Models.Entities;

namespace PTPMQL_MVC.Models.Process
{
    public class ExcelProcess
    {
        public List<Student> ImportExcel(IFormFile file)
        {
            var students = new List<Student>();

            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);

                using (var workbook = new XLWorkbook(stream))
                {
                    var worksheet = workbook.Worksheet(1);

                    var rows = worksheet.RangeUsed().RowsUsed().Skip(1);

                    foreach (var row in rows)
                    {
                        students.Add(new Student
                        {
                            StudentCode = row.Cell(1).GetValue<string>(),
                            FullName = row.Cell(2).GetValue<string>(),
                            FacultyId = row.Cell(3).GetValue<string>()
                        });
                    }
                }
            }

            return students;
        }

        public byte[] ExportExcel(List<Student> students)
        {
            using var workbook = new XLWorkbook();

            var worksheet = workbook.Worksheets.Add("Students");

            worksheet.Cell(1, 1).Value = "StudentCode";
            worksheet.Cell(1, 2).Value = "FullName";
            worksheet.Cell(1, 3).Value = "FacultyId";

            int row = 2;

            foreach (var item in students)
            {
                worksheet.Cell(row, 1).Value = item.StudentCode;
                worksheet.Cell(row, 2).Value = item.FullName;
                worksheet.Cell(row, 3).Value = item.FacultyId;
                row++;
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);

            return stream.ToArray();
        }
    }
}