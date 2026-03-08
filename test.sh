#!/bin/bash

# сборка проекта
dotnet build > /dev/null 2>&1

# Если сборка не удалась - считаем коммит плохим
if [ $? -ne 0 ]; then
    exit 1
fi

# Запуск программы
OUTPUT=$(dotnet run)

# Проверяем корректный вывод
echo "$OUTPUT" | grep "Event parsed" > /dev/null

if [ $? -eq 0 ]; then
    exit 0   # good commit
else
    exit 1   # bad commit
fi