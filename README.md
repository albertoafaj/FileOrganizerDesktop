# 📦 FileOrganizer DesktopApp (WinForms)

[![.NET](https://img.shields.io/badge/.NET-8.0-blueviolet)]()
[![Platform](https://img.shields.io/badge/Platform-Windows-0078D6)]()
[![UI](https://img.shields.io/badge/UI-WinForms-green)]()
[![License](https://img.shields.io/badge/License-MIT-brightgreen)]()

---

# 🖥️ Overview

**FileOrganizer DesktopApp** is a Windows Forms application that allows users to:

* Organize files from an origin directory
* Rename files following a date-based pattern
* Move files into a destination structure (`Year/Month`)
* Remove empty folders recursively
* Log all operations in real time

This app is part of the **FileOrganizer Suite**, working together with the Worker Service in the repository’s root.

---

# 📸 Screenshots

| Main Window                              |
| ---------------------------------------- |
| ![main](../screenshots/desktop_main.png) |

*(Replace the image later with real screenshots.)*

---

# 🎯 Features

### ✔️ Select origin and destination folders

### ✔️ Filter files by extension

### ✔️ Rename using pattern:

```
<OriginalName>_<CreationDate(dd-MM-yyyy)><Extension>
```

### ✔️ Organize into:

```
/Destination/2025/Dez/
```

### ✔️ Clean empty directories (deep cleanup)

* Deletes folders only if:

  * No files exist
  * No subfolders exist
* Performs bottom-up deletion

### ✔️ Visual logs on screen

---

# 📁 Folder Structure (DesktopApp)

```
DesktopApp/
 ├── README.md
 ├── FileOrganizerDesktopApp.csproj
 ├── Form1.cs
 ├── Form1.Designer.cs
 ├── Form1.resx
 ├── /bin
 ├── /obj
```


---

# 🚀 How to Run

### **Debug mode**

```
cd DesktopApp
dotnet run
```

### **Build**

```
dotnet build
```

### **Publish**

```
dotnet publish -c Release -r win-x64 --self-contained true
```

This will generate a standalone executable that runs on Windows without needing the .NET runtime installed.

---

# 🧠 How It Works (Logic Summary)

### **1. Read user input**

* origin directory
* destination directory
* extension filter

### **2. Iterate through all files**

* recursively (`SearchOption.AllDirectories`)

### **3. Validate file extension**

### **4. Extract creation date**

* Format: `dd-MM-yyyy`

### **5. Construct new file name**

```
myfile_03-12-2025.xlsx
```

### **6. Build output path**

```
outputDir/2025/Dez/
```

### **7. Move file**

Creates directories automatically if needed.

### **8. Log actions**

Visible inside the UI.

---

# 🧹 Empty Folder Cleaner

Uses recursion to delete only folders that are truly empty.

### Pseudocode:

```
function Clean(path):
    for each subfolder:
         Clean(subfolder)

    if folder has no files AND no subfolders:
         delete folder
```

---

# 🛠️ Requirements

| Component  | Version                                             |
| ---------- | --------------------------------------------------- |
| Windows    | 10 or later                                         |
| .NET SDK   | 8.0                                                 |
| Permission | Normal mode or worker-executed elevated permissions |

---

# 💡 Integration with WorkerService

This WinForms application can work standalone OR together with the Worker Service:

| Mode                             | Behavior                                                     |
| -------------------------------- | ------------------------------------------------------------ |
| **Standalone**                   | User manually processes files                                |
| **Combined with Service Worker** | Worker handles automation; DesktopApp handles manual actions |

---

# 📄 License

MIT License — Free for personal or commercial use.

---

# 🇧🇷 **VERSÃO EM PORTUGUÊS**

# 📦 FileOrganizer DesktopApp (WinForms)

[![.NET](https://img.shields.io/badge/.NET-8.0-blueviolet)]()
[![Windows](https://img.shields.io/badge/Plataforma-Windows-0078D6)]()
[![UI](https://img.shields.io/badge/Interface-WinForms-green)]()
[![Licença](https://img.shields.io/badge/Licença-MIT-brightgreen)]()

---

# 🖥️ Visão Geral

O **FileOrganizer DesktopApp** é um aplicativo Windows Forms que permite:

* Organizar arquivos por data
* Renomear arquivos automaticamente
* Classificar arquivos em pastas por `Ano/Mês`
* Limpar diretórios vazios
* Exibir logs ao usuário

Faz parte da suíte **FileOrganizer**, junto com o WorkerService.

---

# 🎯 Funcionalidades

* Seleção de diretórios
* Filtro por extensão
* Renomeação com padrão de data
* Organização automática em:

```
/Destino/2025/Dez/
```

* Limpeza de pastas vazias
* Log detalhado

---

# 🚀 Como Executar

### Modo debug

```
cd DesktopApp
dotnet run
```

### Build

```
dotnet build
```

### Publicar

```
dotnet publish -c Release -r win-x64 --self-contained true
```

---

# 📄 Licença

MIT License.

---
