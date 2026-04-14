# HEMO SCAN - Digital Blood Monitoring & Distribution System

HEMO SCAN adalah aplikasi desktop berbasis Windows Forms yang dirancang untuk memantau stok darah secara real-time dan mengoptimalkan distribusi antar unit medis (PMI dan Rumah Sakit). Proyek ini dibuat untuk memenuhi tugas **UCP 1 - Pemrograman Berbasis Objek**.

## 👥 Anggota Tim (A8)
* **Jundi Al-Faruq R** - 20240140100
* **Hafiz Kurniawan** - 20240140024
* **Muhammad Zaki A** - 20240140048

---

## 🛠️ Teknologi yang Digunakan
* **Bahasa Pemrograman:** C# (C-Sharp)
* **Framework:** .NET Framework (Windows Forms)
* **Database:** Microsoft SQL Server (LocalDB)
* **Library:** ADO.NET (SqlConnection, SqlCommand, SqlDataReader)

---

## 📸 Dokumentasi & Bukti Fungsionalitas (UCP 1)

Berikut adalah bukti keberhasilan implementasi fitur sesuai dengan rubrik penilaian:

### 1. Form Koneksi Database (Bagian B)
Status koneksi diperiksa secara otomatis saat aplikasi pertama kali dijalankan untuk memastikan integrasi dengan SQL Server berjalan lancar.
> *Sertakan screenshot pesan "Koneksi Berhasil" di sini.*
<img width="1919" height="1079" alt="Screenshot 2026-04-14 225552" src="https://github.com/user-attachments/assets/3b2d3e15-dc74-4373-982a-50fd465db9b5" />


### 2. Form Dashboard & Tampilan Data (Bagian E)
Data stok darah ditampilkan ke dalam `DataGridView` menggunakan teknik **SqlDataReader** untuk efisiensi memori yang optimal.
<img width="1919" height="1079" alt="Screenshot 2026-04-14 225614" src="https://github.com/user-attachments/assets/953e0746-1778-4800-9aea-f7ad2b1e6006" />


### 3. Operasi CRUD (Bagian D & F)

#### A. Insert & Validasi Input
Menambahkan data kantong darah baru dengan validasi agar tidak ada field penting yang kosong.
<img width="1918" height="1078" alt="Screenshot 2026-04-14 225640" src="https://github.com/user-attachments/assets/e237a7c1-dce5-432a-a84a-312fc05ed02f" />


#### B. Update & Konfirmasi Perubahan
Mengubah data yang sudah ada dengan fitur **Konfirmasi (Yes/No)** sebelum data diperbarui di database.
<img width="1919" height="1079" alt="Screenshot 2026-04-14 225702" src="https://github.com/user-attachments/assets/cae2afed-06b1-4356-8a5c-ea454a40c46a" />


#### C. Delete & Konfirmasi Hapus
Menghapus data stok dengan proteksi pesan konfirmasi untuk mencegah kesalahan penghapusan.
<img width="1919" height="1079" alt="Screenshot 2026-04-14 225702" src="https://github.com/user-attachments/assets/f4de2243-934e-49b8-b191-d2f838a0c84a" />


### 4. Fitur Pencarian & ExecuteScalar (Bagian D & E)
* **Pencarian:** Mencari stok darah berdasarkan golongan darah secara dinamis.
* **ExecuteScalar:** Menampilkan total record/stok pada label di bagian bawah dashboard.
<img width="1919" height="1079" alt="image" src="https://github.com/user-attachments/assets/b5613072-b891-41b3-9eda-32a83e9149d5" />


---
