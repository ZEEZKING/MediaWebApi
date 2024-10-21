# Media API Project

This is a simple Media API built with ASP.NET Core for managing file uploads, downloads, and voice recordings.

## Features

- Upload files (images, documents, audio)
- Download files via unique IDs
- Record and store voice files
- Fetch and serve media from the server

## Endpoints

### Upload Media
`POST /api/Media/upload`
- Allows users to upload media files (e.g., images, documents).

### Download Media
`GET /api/Media/download/{id}`
- Downloads a specific file by its unique ID.

### Upload Audio Recording
`POST /api/Media/upload-audio`
- Uploads an audio recording.

### Download Audio Recording
`GET /api/Media/download-audio/{fileName}`
- Downloads a recorded audio file by name.

## Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/media-api-project.git

2. Navigate to the project folder:

```bash
cd media-api-project

3. Run the application
```bash
dotnet run

