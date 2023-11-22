
-- Bảng Người Dùng
CREATE TABLE NguoiDung (
    id INT IDENTITY(1,1) PRIMARY KEY,
    hoten NVARCHAR(255),
    sodienthoai NVARCHAR(20),
    diachi NVARCHAR(255),
    chucvu NVARCHAR(50),
    matkhau NVARCHAR(255),
    tendangnhap NVARCHAR(50)
);

-- Bảng Phòng
CREATE TABLE Phong (
    id INT IDENTITY(1,1) PRIMARY KEY,
    loaiphong NVARCHAR(50),
    sogiuong INT,
    songuoio INT,
    giaphong FLOAT
);

-- Bảng Sinh Viên
CREATE TABLE SinhVien (
    id NVARCHAR(255) PRIMARY KEY,
    tensinhvien NVARCHAR(255),
    khoahoc NVARCHAR(255),
    nganhhoc NVARCHAR(255),
    email NVARCHAR(50),
    sodienthoai NVARCHAR(20),
    idphong INT,
    gioitinh NVARCHAR(10),
    quequan NVARCHAR(255),
    trang_thai NVARCHAR(20),
    solanvipham INT,
    ngayvao DATE,
    ngaysinh DATE,
    FOREIGN KEY (idphong) REFERENCES Phong(id)
);

-- Bảng Chuyển Phòng
CREATE TABLE ChuyenPhong (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idsinhvien NVARCHAR(255),
    idnguoidung INT,
    idphongcu INT,
    idphongmoi INT,
    lydo NVARCHAR(255),
    ngaychuyen DATE,
    FOREIGN KEY (idsinhvien) REFERENCES SinhVien(id),
    FOREIGN KEY (idnguoidung) REFERENCES NguoiDung(id),
    FOREIGN KEY (idphongcu) REFERENCES Phong(id),
    FOREIGN KEY (idphongmoi) REFERENCES Phong(id)
);

-- Bảng Thuê Phòng
CREATE TABLE ThuePhong (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idnguoidung INT,
    idphong INT,
    trangthai NVARCHAR(20),
    idsinhvien NVARCHAR(255),
    ngaythue DATE,
    FOREIGN KEY (idnguoidung) REFERENCES NguoiDung(id),
    FOREIGN KEY (idphong) REFERENCES Phong(id),
    FOREIGN KEY (idsinhvien) REFERENCES SinhVien(id)
);

-- Bảng Trả Phòng
CREATE TABLE TraPhong (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idsinhvien NVARCHAR(255),
    idnguoidung INT,
    idphong INT,
    lydo NVARCHAR(255),
    ngaytra DATE,
    FOREIGN KEY (idsinhvien) REFERENCES SinhVien(id),
    FOREIGN KEY (idnguoidung) REFERENCES NguoiDung(id),
    FOREIGN KEY (idphong) REFERENCES Phong(id)
);

CREATE TABLE DichVu (
    id INT IDENTITY(1,1) PRIMARY KEY,
    tendichvu NVARCHAR(255),
    mota TEXT,
    giatien FLOAT,
    soluongcon INT,
    trangthai NVARCHAR(20),
    ngaythem DATE,
);


CREATE TABLE ThueDichVu (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idnguoidung INT,
    idthuephong INT,
    iddichvu INT,
    soluongthue INT,
    thanhtien FLOAT,
    idsinhvien NVARCHAR(255),
    trangthai NVARCHAR(20),
    ngaythue DATE,
    FOREIGN KEY (iddichvu) REFERENCES DichVu(id),
    FOREIGN KEY (idnguoidung) REFERENCES NguoiDung(id),
    FOREIGN KEY (idthuephong) REFERENCES ThuePhong(id),
    FOREIGN KEY (idsinhvien) REFERENCES SinhVien(id)
);


CREATE TABLE KyLuat (
    id INT IDENTITY(1,1) PRIMARY KEY,
    loaivipham NVARCHAR(255),
    mota TEXT,
    phuongphapxuphat NVARCHAR(255),
    idnguoidung INT,
    idsinhvien NVARCHAR(255),
    ngayvipham DATE,
    FOREIGN KEY (idnguoidung) REFERENCES NguoiDung(id),
    FOREIGN KEY (idsinhvien) REFERENCES SinhVien(id)
);

CREATE TABLE ThongTinKhenThuong (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idsinhvien NVARCHAR(255),
    idnguoidung INT,
    lydo NVARCHAR(255),
    ngaykhen DATE,
    FOREIGN KEY (idsinhvien) REFERENCES SinhVien(id),
    FOREIGN KEY (idnguoidung) REFERENCES NguoiDung(id)
);


INSERT INTO NguoiDung (hoten, sodienthoai, diachi, chucvu, matkhau, tendangnhap)
VALUES ('Vo Van Chinh', '0123456789', '123 qt', 'Admin', '123', 'adminn');
