@echo off
setlocal enabledelayedexpansion

for /f "tokens=1-4 delims=/ " %%a in ('date /t') do (
    set today=%%d_%%b_%%c
)
for /f "tokens=1-2 delims=: " %%a in ('time /t') do (
    set tm=%%a%%b
)
set migration=Migration_%date:~-4%%date:~3,2%%date:~0,2%_%time:~0,2%%time:~3,2%%time:~6,2%
set migration=%migration: =0%
set migration=%migration::=_% 

dotnet ef migrations add %migration%
endlocal
PAUSE