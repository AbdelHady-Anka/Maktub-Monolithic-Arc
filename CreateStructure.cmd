dotnet new sln -n Maktub

REM dotnet "new" "webapi" "-lang" "C#" "-n" "Maktub.Presentation" "-o" "src\Presentation"
REM dotnet "new" "classlib" "-lang" "C#" "-n" "Maktub.CrossCuttingConcerns" "-o" "src\CrossCuttingConcerns"
REM dotnet "new" "classlib" "-lang" "C#" "-n" "Maktub.Domain" "-o" "src\Domain"
REM dotnet "new" "classlib" "-lang" "C#" "-n" "Maktub.Infrastructure" "-o" "src\Infrastructure"
REM dotnet "new" "classlib" "-lang" "C#" "-n" "Maktub.Persistance" "-o" "src\Persistance"
REM dotnet "new" "classlib" "-lang" "C#" "-n" "Maktub.Application" "-o" "src\Application"

dotnet "sln" "Maktub.sln" "add" "src\Presentation\Maktub.Presentation.csproj"
dotnet "sln" "Maktub.sln" "add" "src\CrossCuttingConcerns\Maktub.CrossCuttingConcerns.csproj"
dotnet "sln" "Maktub.sln" "add" "src\Domain\Maktub.Domain.csproj"
dotnet "sln" "Maktub.sln" "add" "src\Infrastructure\Maktub.Infrastructure.csproj"
dotnet "sln" "Maktub.sln" "add" "src\Persistance\Maktub.Persistance.csproj"
dotnet "sln" "Maktub.sln" "add" "src\Application\Maktub.Application.csproj"
