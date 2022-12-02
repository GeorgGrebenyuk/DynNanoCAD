# DynNanoCAD
Репозиторий с исходным кодом для пакета нодов среды Autodesk Dynamo для поддержки платформы nanoCAD

# Описание реализации и ограничения
[См. выступление на nanoCAD API DAY](https://www.youtube.com/watch?v=eKz8k2Lr-rc&t=19357s)

Текстовая версия будет позже.

# Об установке среды Dynamo и загрузке пакета нодов

1. Скачиваем DynamoCoreRuntime [отсюда](https://dynamobuilds.com) и распаковываем. Тестировалось на версии 2.12.1 
2. Загружаем из раздела [Releases](https://github.com/GeorgGrebenyuk/DynNanoCAD/releases) последнюю версию пакета нодов и распаковываем; 
3. Запускаем из распакованного архива файл `DynamoSandbox.exe`, далее идет Файл -> Импорт библиотеки -> Указываем путь к файлу `DynNCAD.dll` из предыдущего распакованного архива;
4. Пользуемся библиотекой

Отдельные скрипты приведены [в папке](https://github.com/GeorgGrebenyuk/DynNanoCAD/tree/main/scripts_dyn) `scripys_dyn` настоящего репозитория. Часть подходов кратко [показывалось в видеозаписи](https://www.youtube.com/watch?v=eKz8k2Lr-rc&t=19357s) презентации решения на nanoCAD API DAY. 
