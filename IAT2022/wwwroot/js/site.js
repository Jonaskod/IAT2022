
const db = new sqlite3.Database('./IATDB.db')
db.all("SELECT * FROM CUSTOMERQUESTIONS")
let answer = db.get("SELECT * FROM CUSTOMERQUESTIONS")
console.log(answer);