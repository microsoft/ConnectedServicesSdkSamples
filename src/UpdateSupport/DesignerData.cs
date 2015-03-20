using System.Runtime.Serialization;

namespace Contoso.Samples.ConnectedServices.UpdateSupport
{
    /// <summary>
    /// A data structure that holds the designer information in the ConnectedService.json file.
    /// This is the information that is persisted during "Add" so it can be read during "Update".
    /// </summary>
    [DataContract]
    public class DesignerData
    {
        [DataMember(Name = "extraInformation")]
        public string ExtraInformation { get; set; }
    }
}
