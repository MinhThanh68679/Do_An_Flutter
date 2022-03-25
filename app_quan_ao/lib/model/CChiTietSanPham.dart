import 'package:app_quan_ao/model/CSanPham.dart';
import 'package:flutter/material.dart';
  // ignore: non_constant_identifier_names

class ChiTietSanPham {
  final String id, maSp, color, tenSp, size, image, motaSp;
  final int dongia, soluong;
  //final SanPham sp;
  ChiTietSanPham({
    required this.id,
    required this.maSp,
    //required this.sp,
    required this.color,
    required this.tenSp,
    required this.size,
    required this.image,
    required this.motaSp,
    required this.dongia,
    required this.soluong,
  });

  factory ChiTietSanPham.fromJson(Map<String, dynamic> json) {
    return ChiTietSanPham(
      id: json['maCTSP'],
      //sp: json['sanPham'],
      maSp: json['sanPhamMaSP'],
      color: json['color'],
      tenSp: json['gioTinh'],
      size: json['size'],
      image: json['anh'],
      motaSp: json['moTaSP'],
      dongia: json['donGia'],
      soluong: json['sl'],
    );
  }
}