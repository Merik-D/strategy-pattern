# strategy-pattern

This is a console application that demonstrates the **Strategy** design pattern for output handling. Based on the configuration, the output can be sent to the console, Kafka, Redis.

---

## 📦 Available Commands

The application supports two main commands:

| Command  | Description |
|----------|-------------|
| `fetch`  | Downloads data from the source URL (defined in `appsettings.json`) and saves it to `data.json`. |
| `run`    | Reads data from `data.json` and processes it using the configured output strategy. |

---

## 🚀 How to Run

### 1. Restore dependencies
```bash
dotnet restore
```
### 2. Build the project
```bash
dotnet build
```
### 3. Run a command
```bash
dotnet run fetch
```
```bash
dotnet run run
```

Make sure to run fetch before run, otherwise data.json will not be found.
