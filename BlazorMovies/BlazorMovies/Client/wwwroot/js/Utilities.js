function testNETStatic() {
    DotNet.invokeMethodAsync("BlazorMovies.Client", "GetCurrentCount").then(result => {
        console.log('Count from JS ' + result);
    });
}