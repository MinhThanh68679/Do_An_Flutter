// ignore: unused_import
import 'package:flutter/material.dart';

class Product {
  final int id, price;
  final String title, description, image;
  final double rating;

  Product({
    required this.id,
    required this.image,
    this.rating = 0.0,
    required this.title,
    required this.price,
    required this.description,
  });
}

// Our food Products

List<Product> shopProducts = [
  Product(
    id: 1,
    image: 'assets/images/ao_thun_1.jpg',
    title: "Áo Thun Cổ Tròn Y Nguyên Bản 18- Ver25",
    price: 50,
    description: description,
    rating: 4.8,
  ),
  Product(
    id: 2,
    image: "assets/images/ao_thun_2.jpg",
    title: "Áo Thun Cổ Tròn Y Nguyên Bản 18- Ver25",
    price: 51,
    description: description,
    rating: 4.1,
  ),
  Product(
    id: 3,
    image: "assets/images/ao_thun_3.jpg",
    title: "Áo Thun Cổ Tròn Y Nguyên Bản 18- Ver25",
    price: 52,
    description: description,
    rating: 4.0,
  ),
  Product(
    id: 4,
    image: "assets/images/ao_thun_4.jpg",
    title: "Áo Thun Cổ Tròn Y Nguyên Bản 18- Ver25",
    price: 53,
    description: description,
    rating: 4.1,
  ),
  Product(
    id: 5,
    image: "assets/images/ao_thun_5.jpg",
    title: "Áo Thun Cổ Tròn Y Nguyên Bản 18- Ver25",
    price: 54,
    description: description,
    rating: 4.2,
  ),
  Product(
    id: 6,
    image: "assets/images/ao_thun_6.jpg",
    title: "Áo Thun Cổ Tròn Y Nguyên Bản 18- Ver25",
    price: 55,
    description: description,
    rating: 4.5,
  ),
];

const String description =
    "Đối với chương thứ hai của bộ sưu tập hợp tác này, một chiến dịch mới do cặp song sinh người Pháp Jalan và Jibril Durimel thực hiện có sự góp mặt của những nhà thám hiểm gan dạ của Gucci, đi bộ đường dài qua đảo Iceland thuộc Bắc Âu trên bối cảnh là cát đen núi lửa, những ngọn đồi xanh mướt và sông băng.";
