nuget pack ..\PipesAndFilters.csproj -Prop Configuration=Release
nuget setApiKey 693856da-3348-471c-b5d3-9eafff9cc92d
nuget push *.nupkg
del *.nupkg

PAUSE