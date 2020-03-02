dotnet new sln -n maktoob

REM dotnet "new" "angular" "--auth" "Individual" "-lang" "C#" "-n" "maktoob.Presentation" "-o" "src\Presentation"
REM dotnet "new" "classlib" "-lang" "C#" "-n" "maktoob.CrossCuttingConcerns" "-o" "src\CrossCuttingConcerns"
REM dotnet "new" "classlib" "-lang" "C#" "-n" "maktoob.Domain" "-o" "src\Domain"
REM dotnet "new" "classlib" "-lang" "C#" "-n" "maktoob.Infrastructure" "-o" "src\Infrastructure"
REM dotnet "new" "classlib" "-lang" "C#" "-n" "maktoob.Persistance" "-o" "src\Persistance"
REM dotnet "new" "classlib" "-lang" "C#" "-n" "maktoob.Application" "-o" "src\Application"

dotnet "sln" "maktoob.sln" "add" "src\Presentation\maktoob.Presentation.csproj"
dotnet "sln" "maktoob.sln" "add" "src\CrossCuttingConcerns\maktoob.CrossCuttingConcerns.csproj"
dotnet "sln" "maktoob.sln" "add" "src\Domain\maktoob.Domain.csproj"
dotnet "sln" "maktoob.sln" "add" "src\Infrastructure\maktoob.Infrastructure.csproj"
dotnet "sln" "maktoob.sln" "add" "src\Persistance\maktoob.Persistance.csproj"
dotnet "sln" "maktoob.sln" "add" "src\Application\maktoob.Application.csproj"
