"""Create files_db.sqlite database"""

import sqlite3
import time
import random

DB_NAME = 'files_db.sqlite'

def init_db():
    """Create database tables and indexes"""

    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    cursor.execute('DROP TABLE IF EXISTS bannedWords')
    cursor.execute('CREATE TABLE bannedWords (id INTEGER PRIMARY KEY AUTOINCREMENT, wordText TEXT)')
    cursor.execute('CREATE INDEX main_idx on bannedWords (id, wordText)')
    cursor.execute('DROP TABLE IF EXISTS fileInfo')
    cursor.execute('CREATE TABLE fileInfo (id INTEGER PRIMARY KEY AUTOINCREMENT, filePath TEXT, bannedWords TEXT)')
    cursor.execute('CREATE INDEX fileInfo_idx on fileInfo (id, filePath)')
    conn.commit()
    conn.close()

if __name__ == '__main__':
    init_db()

    print("--- Database Created ---")
