import { utils, writeFile } from 'xlsx'

function renameKeys(obj, newKeys) {
  const keyValues = Object
    .entries(newKeys)
    .map(([oldKey, newKey]) => ({ [newKey]: obj[oldKey] }))
  return Object.assign({}, ...keyValues)
}

export default {
  methods: {
    //    Excel
    //  Конвертирование данных
    convertJsonData(json, newKeys, checkStr) {
      json = json.reduce((arr, obj) => {
        const newObj = {...obj}

        //  Проверка условий для добавления обхекта в выгрузку
        if (Array.isArray(checkStr) && checkStr.reduce((cond, str) => {
            if (cond && Array.isArray(str))
              cond = str.some(compStr => newObj[compStr])
            else if (cond)
              cond = newObj[str] ? true : false
            return cond
          }, true)
        )
          arr.push(renameKeys(newObj, newKeys))
        else if (typeof checkStr === 'string' && newObj[checkStr])
          arr.push(renameKeys(newObj, newKeys))
        else if (!checkStr)
          //  Переименование столбцов
          arr.push(renameKeys(newObj, newKeys))

        return arr
      }, [])

      return json
    },
    //  XLSX преобразования
    convertToXLSX(json, filenameStr) {
      const workbook = utils.book_new()
      if (!workbook.Props) workbook.Props = {
        Title: filenameStr,
        CreatedDate: new Date(),
        Subject: filenameStr,
        Category: filenameStr,
        Keywords: filenameStr,
        Comments: filenameStr
      }
      workbook.ignoreEC = false
      const worksheet = utils.json_to_sheet(json)
      utils.book_append_sheet(workbook, worksheet, `Лист 1`)
      return workbook
    },

    async downloadCreatedFile({workbook, filenameStr}) {
      await writeFile(workbook, `${filenameStr}.xlsx`)
    },
  },
}