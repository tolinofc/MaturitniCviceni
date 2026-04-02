import mysql from 'mysql2/promise'
export const pool = mysql.createPool( {
    host: 'mysqlstudenti.litv.sssvt.cz',
    user: 'jandatomas',
    password: '123456',
    database: '4b2_jandatomas_db1'
})