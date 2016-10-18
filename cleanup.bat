for /d /r . %%d in (obj,debug) do @if exist "%%d" rd /s/q "%%d"
for /d /r . %%d in (bin) do @if exist "%%d" rd /s/q "%%d"
for /d /r . %%d in (.vs) do @if exist "%%d" rd /s/q "%%d"