import 'package:flutter/material.dart';
class User {
  final String email, pass, name, phone,image,id;
  User({
    required this.id,
    required this.email,
    required this.pass,
    required this.name,
    required this.phone,
    required this.image,
  });

  factory User.fromJson(Map<String, dynamic> json) {
    return User(
      id: json['maKH'],
      email: json['email'],
      pass: json['pass'],
      name: json['tenKH'],
      phone: json['sdt'],
      image: json['avatar']
    );
  }
}