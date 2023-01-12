using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/user", () => new {Name = "João Vinícius", Age = 20});
app.MapGet("/AddHeaderr", (HttpResponse response) => {
    response.Headers.Add("Teste", "Joao Vinicius");
    return new {Name = "Joao Vinicius", Age = 20};
});

app.MapPost("/saveproducts", ([FromBody] Product product) => {
    return product.Code + " - " + product.Name;
});

app.MapGet("/getproducts", ([FromQuery] string dateStart, [FromQuery] string dateEnd ) => {
    return dateStart + " - " + dateEnd;
});

app.MapGet("/getproducts/{code}", ([FromRoute] string code ) => {
    return code;
});

app.MapGet("/getproduct", (HttpRequest request) => {
    return request.Headers["product-code"].ToString();
});



app.Run();

public class Product {
    public string Code { get; set; }
    public string Name { get; set; }

}