namespace WebApplication1.App_Start
{
    internal class HostAuthenticationFilter
    {
        private object authenticationType;

        public HostAuthenticationFilter(object authenticationType)
        {
            this.authenticationType = authenticationType;
        }
    }
}