using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.UI
{
    [Serializable]
    public class RecordSerializable
    {
        public int GuiID { get; set; }
        public string GuiName { get; set; }
        public string GuiDescription { get; set; }
        public decimal GuiPrice { get; set; }
        public int GuiQuantity { get; set; }
        public string GuiCategory { get; set; }

        // Default constructor sets members to default values
        public RecordSerializable() : this(0, string.Empty, string.Empty, 0M, 0, string.Empty) { }

        public RecordSerializable(int guiID, string guiName, string guiDescription, decimal guiPrice, int guiQuantity, string guiCategory)
        {
            GuiID = guiID;
            GuiName = guiName;
            GuiDescription = guiDescription;
            GuiPrice = guiPrice;
            GuiQuantity = guiQuantity;
            GuiCategory = guiCategory;
        }
    }
}
