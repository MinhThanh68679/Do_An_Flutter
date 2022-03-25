import 'package:app_quan_ao/Network/GetList.dart';
import 'package:app_quan_ao/model/CChiTietSanPham.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:app_quan_ao/constant.dart';
import 'package:app_quan_ao/model/shop_model.dart';
import 'package:app_quan_ao/pages/Home/detail_screen/detail_screen.dart';
import 'dart:async';
import 'dart:convert';
import 'package:http/http.dart' as http;

class ShopCard extends StatelessWidget {
  const ShopCard({
    Key? key,
    required this.CTSPs,
  }) : super(key: key); 

  final List<ChiTietSanPham> CTSPs;

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(10.0),
      child: GridView.builder(
          shrinkWrap: true,
          physics: ScrollPhysics(),
          itemCount: CTSPs.length,
          gridDelegate: const SliverGridDelegateWithFixedCrossAxisCount(
            crossAxisCount: 2,
            childAspectRatio: 0.64,
            mainAxisSpacing: 10.0,
            crossAxisSpacing: 10.0,
          ),
          itemBuilder: (context, index) => ShopProduct(
                press: () {
                  Navigator.push(
                      context,
                      MaterialPageRoute(
                          builder: (context) => DetailScreen(
                                shopDetail: CTSPs[index],
                              )));
                },
                product: CTSPs[index],
              )),
    );
  }
}

class ShopProduct extends StatelessWidget {
  const ShopProduct({
    Key? key,
    required this.product,
    required this.press,
  }) : super(key: key);
  final ChiTietSanPham product;
  final VoidCallback press;

  @override
  Widget build(BuildContext context) {
    return InkWell(
      onTap: press,
      child: Container(
        padding: const EdgeInsets.all(10.0),
        decoration: BoxDecoration(
            color: kSecondaryColor.withOpacity(0.3),
            borderRadius: BorderRadius.circular(15.0)),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Image.asset(product.image),
            Text(
              product.tenSp,
              style: const TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
            ),
            Row(
              children: [
                Text(
                  "\$${product.dongia}",
                  style: const TextStyle(
                      color: kPrimaryColor,
                      fontSize: 14,
                      fontWeight: FontWeight.bold),
                ),
                const Spacer(),
                const SizedBox(
                  height: 10.0,
                ),
                const Icon(
                  Icons.inventory_2_outlined,
                  size: 20,
                  color: kPrimaryColor,
                ),
                Text(
                  "${product.soluong}",
                  style: const TextStyle(
                    color: kPrimaryColor,
                    fontSize: 14,
                  ),
                ),
              ],
            )
          ],
        ),
      ),
    );
  }
}
