namespace EnumDispalyName.Enum.Models
{
    public class StatusViewModel : EnumViewModel
    {
        public override void SetEnum()
        {
            this.EnumValues = System.Enum.GetValues(typeof(Status));
        }
    }
}
