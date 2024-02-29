COPY *.csproj ./
RUN dotnet restore

# Copy the remaining source code
COPY . .

# Build the application
RUN dotnet build -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

# Final stage / production stage
FROM mcr.microsoft.com/dotnet/aspnet:8 AS final
WORKDIR /app

# Copy the published application
COPY --from=publish /app/publish .

# Expose port 80
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "Dev-Ops-mat.dll"]