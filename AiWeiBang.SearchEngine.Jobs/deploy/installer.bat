@echo 正在安装服务

sc create "AiWeiBang.SearchEngine.Jobs" binpath= "%~dp0..\AiWeiBang.SearchEngine.Jobs" displayname= "AiWeiBang.SearchEngine.Jobs"
net start "AiWeiBang.SearchEngine.Jobs"

pause
