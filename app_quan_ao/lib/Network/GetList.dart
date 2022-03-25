
import 'dart:convert';
import 'package:flutter/foundation.dart';
import 'package:app_quan_ao/model/CChiTietSanPham.dart';
import 'package:http/http.dart' as http;

class GetList{
  static const url = 'https://localhost:44313/Api/SP';
  
  static List<ChiTietSanPham> parseCTSP(String responseBody){
    var list = json.decode(responseBody) as List<dynamic>;
    List<ChiTietSanPham> ctsps= list.map((model) => ChiTietSanPham.fromJson(model)).toList();
    return ctsps;
  }

  static Future<List<ChiTietSanPham>> fetchCTSP() async{
    final response = await http.get(Uri.parse('$url'));
    if(response.statusCode == 200){
      return compute(parseCTSP,response.body);
    }else {
      throw Exception('Can\'t get list');
    }
  }

}