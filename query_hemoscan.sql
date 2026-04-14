CREATE DATABASE HEMOSCAN;
GO -- Gunakan GO agar database dibuat dulu sebelum tabel

USE HEMOSCAN; -- PENTING: Masuk ke database HEMOSCAN sebelum membuat tabel
GO

CREATE TABLE Tabel_Kantong_Darah (
    ID_Kantong INT PRIMARY KEY IDENTITY,
    Gol_Darah VARCHAR(2),
    Rhesus VARCHAR(3),
    Tgl_Kadaluwarsa DATE,
    Status VARCHAR(20),
    ID_Unit INT
);

CREATE TABLE Tabel_Unit_Medis (
    ID_Unit INT PRIMARY KEY IDENTITY,
    Nama_Unit VARCHAR(100),
    Alamat VARCHAR(255),
    Kategori VARCHAR(20)
);

CREATE TABLE Tabel_Permintaan (
    ID_Request INT PRIMARY KEY IDENTITY,
    ID_Unit_Asal INT,
    ID_Unit_Tujuan INT,
    Jumlah INT,
    Status_Permintaan VARCHAR(20),
    Tanggal_Request DATETIME
);

CREATE TABLE Tabel_User (
    Username VARCHAR(50) PRIMARY KEY,
    Password VARCHAR(50) NOT NULL,
    Role VARCHAR(20) NOT NULL -- Isinya: adminPMI, stafRS, atau Manajer
);

-- Masukkan data contoh untuk ngetes login
INSERT INTO Tabel_User (Username, Password, Role) VALUES 
('admin1', 'admin123', 'adminPMI'),
('staf1', 'staf123', 'stafRS'),
('bos1', 'manajer123', 'Manajer');

USE HEMOSCAN;
GO

CREATE TABLE Tabel_Request (
    ID_Request INT PRIMARY KEY IDENTITY(1,1), -- ID otomatis (1, 2, 3...)
    Golongan_Darah VARCHAR(5) NOT NULL,
    Status_Permintaan VARCHAR(20) DEFAULT 'Pending', -- Status awal selalu Pending
    Tanggal_Request DATETIME DEFAULT GETDATE(),      -- Otomatis mencatat waktu klik
    Nama_RS VARCHAR(50) DEFAULT 'RS Sehat'          -- Penanda RS mana yang minta
);

SELECT * FROM Tabel_Request;