using YouBankruptBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace YouBankruptBusinessLogic.HelperModels
{
    public class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportComponentPackageViewModel> ComponentPackage { get; set; }
    }
}
