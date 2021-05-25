using System;
using System.Collections.Generic;
using System.Text;

namespace YouBankruptBusinessLogic.HelperModels
{
    public class WordParagraphSupplier
    {
        public List<(string, WordTextPropertiesSupplier)> Texts { get; set; }
        public WordTextPropertiesSupplier TextProperties { get; set; }
    }
}
