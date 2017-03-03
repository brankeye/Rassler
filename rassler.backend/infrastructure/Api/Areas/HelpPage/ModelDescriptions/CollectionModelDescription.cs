using Api.Areas.HelpPage.ModelDescriptions;

namespace rassler.backend.domain.Data.ModelDescriptions
{
    public class CollectionModelDescription : ModelDescription
    {
        public ModelDescription ElementDescription { get; set; }
    }
}