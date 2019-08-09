using System.ComponentModel;

namespace FundamentalTools.Resources
{
    public enum GenderEnum
    {
        Undefined = 0,
        [Description("MaleDescription")]
        Male = 1,
        [Description("FemaleDescription")]
        Female = 2
    }
}