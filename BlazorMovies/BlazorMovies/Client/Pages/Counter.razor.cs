using Microsoft.AspNetCore.Components;

namespace BlazorMovies.Client.Pages
{
    public partial class Counter
    {
        [Inject] ServicesSingleton singleton { get; set; } = null!;
        [Inject] ServicesTransient transient { get; set; } = null!;

        //Miembro de instacia
        private int currentCount = 0;
        //Static
        private static int currentCountStatic = 0;

        private void IncrementCount()
        {
            currentCount++;
            currentCountStatic = currentCount;
            singleton.Value = currentCount;
            transient.Value = currentCount;
        }

        public static Task<int> GetCurrentCount()
        {
            return Task.FromResult(currentCountStatic);
        }
    }
}
