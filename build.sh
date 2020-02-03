
dotnet build
mkdir -p ./Demo/bin/Debug/netcoreapp3.1/Mods
cp ./ModWindow/bin/Debug/netstandard2.0/*.dll ./Demo/bin/Debug/netcoreapp3.1/Mods
cp ./ModLogger/bin/Debug/netstandard2.0/*.dll ./Demo/bin/Debug/netcoreapp3.1/Mods
cp ./ModRenderer/bin/Debug/netstandard2.0/*.dll ./Demo/bin/Debug/netcoreapp3.1/Mods