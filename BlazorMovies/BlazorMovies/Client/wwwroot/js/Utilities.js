function testNETStatic() {
    DotNet.invokeMethodAsync("BlazorMovies.Client", "GetCurrentCount").then(result => {
        console.log('Count from JS ' + result);
    });
}

function testNETInstance(dotNetHelper) {
    //dotNetHelper.invokeMethodAsync("IncrementCount").then(resultado => ) si me retornara algo el método
    dotNetHelper.invokeMethodAsync("IncrementCount");
}