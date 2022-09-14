namespace TapiFramework.Attributes;

[AttributeUsage(validOn:AttributeTargets.Property)]
public class PropertyKey : Attribute
{
    #region Constructor

    public PropertyKey(string nameColunm)
    {
        NameColunm = nameColunm;
    }

    #endregion

    #region Properties

    public string NameColunm { get; set; }

    #endregion
}