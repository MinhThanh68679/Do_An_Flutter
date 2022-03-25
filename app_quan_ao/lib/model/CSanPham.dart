import 'package:flutter/material.dart';

class SanPham{
  final String maSp, tenSP, loaiSP;

  SanPham({
    required this.maSp, 
    required this.tenSP, 
    required this.loaiSP
    });

 factory SanPham.fromJson(Map<String, dynamic> json){
   return SanPham(
     maSp: json['maSp'],
     tenSP: json['tenSP'],
     loaiSP: json['loaisanpham'],
   );
 }
}