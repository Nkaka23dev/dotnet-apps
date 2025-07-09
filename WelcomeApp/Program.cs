var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => Results.Content(@"
<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <title>Welcome</title>
    <style>
        body {
            background: #000000;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }

        .welcome-box {
            background-color: white;
            padding: 40px 60px;
            border-radius: 12px;
            box-shadow: 0 8px 20px rgba(0, 0, 0, 0.1);
            text-align: center;
        }

        .welcome-box h1 {
            color: #333;
            margin: 0;
            font-size: 2.5rem;
        }

        .welcome-box p {
            color: #666;
            margin-top: 12px;
        }
    </style>
</head>
<body>
    <div class='welcome-box'>
        <h1>Welcome</h1>
        <p>Your ASP.NET Core Web App is up and running!</p>
    </div>
</body>
</html>
", "text/html"));

app.Run();
