using Microsoft.AspNetCore.Components;

namespace BlazorMovies.Client.Pages
{
    public partial class Counter
    {
        [Inject] ServicesSingleton singleton { get; set; } = null!;
        [Inject] ServicesTransient transient { get; set; } = null!;

        private int currentCount = 0;

        private void IncrementCount()
        {
            currentCount++;
            singleton.Value = currentCount;
            transient.Value = currentCount;
        }
    }
}
