import 'package:app_quan_ao/model/CChiTietSanPham.dart';
import 'package:flutter/material.dart';
import 'package:app_quan_ao/constant.dart';
import 'package:app_quan_ao/model/shop_model.dart';
import 'package:app_quan_ao/pages/Home/components/bottom_bar.dart';
import 'package:app_quan_ao/pages/Home/components/enum.dart';
import 'dart:convert';
import 'package:http/http.dart' as http;

class DetailScreen extends StatefulWidget {
  final ChiTietSanPham shopDetail;
  const DetailScreen({Key? key, required this.shopDetail}) : super(key: key);

  @override
  _DetailScreenState createState() => _DetailScreenState();
}

class _DetailScreenState extends State<DetailScreen> {
  int counter =0;
  int dongia =0;
  int thanhtien = 0; 
  @override
  void initState() {
    // TODO: implement initState
    dongia =widget.shopDetail.dongia;
  }
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: kSecondaryColor.withOpacity(0.3),
        title: Text(widget.shopDetail.tenSp,
            style: const TextStyle(
              color: kTextGrayColor,
            )),
        elevation: 0,
        iconTheme: const IconThemeData(color: Colors.black),
      ),
      bottomNavigationBar: const CustomBottomBar(selectMenu: MenuState.home),
      body: SafeArea(
          child: SingleChildScrollView(
        child: Column(
          children: [
            Container(
              height: MediaQuery.of(context).size.height * 0.4,
              width: double.infinity,
              decoration: BoxDecoration(
                  color: kSecondaryColor.withOpacity(0.3),
                  borderRadius: const BorderRadius.only(
                    bottomLeft: Radius.circular(20.0),
                    bottomRight: Radius.circular(20.0),
                  )),
              child: Image.asset(
                widget.shopDetail.image,
              ),
            ),
            Padding(
              padding:
                  const EdgeInsets.symmetric(horizontal: 15.0, vertical: 20.0),
              child: Column(
                children: [
                  Text(widget.shopDetail.motaSp,
                      style: TextStyle(
                        color: Colors.green[800],
                        fontSize: 15,
                      )),
                  const SizedBox(
                    height: 20,
                  ),
                  Row(
                    children: [
                      Text(
                        "\$${thanhtien}",
                        style: const TextStyle(
                            color: kTextGrayColor,
                            fontSize: 18,
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
                        "${widget.shopDetail.soluong}",
                        style: const TextStyle(
                          color: kPrimaryColor,
                          fontSize: 14,
                        ),
                      ),
                    ],
                  ),
                  const SizedBox(
                    height: 20,
                  ),
                  Row(
                    children: [
                      InkWell(
                        onTap: () {},
                        child: Container(
                          height: 45,
                          width: 45,
                          decoration: BoxDecoration(
                              color: kSecondaryColor,
                              borderRadius: BorderRadius.circular(10.0)),
                          child: ElevatedButton(
                              onPressed: () {setState(() {
                                if(counter>1){
                                  counter--;
                                  thanhtien = dongia * counter;
                                }
                              });}, 
                              child: const Icon(Icons.remove),
                            ),
                        ),
                      ),
                      const SizedBox(
                        width: 8.0,
                      ),
                      Text(
                        "$counter",
                        style: TextStyle(
                          color: kTextGrayColor,
                          fontSize: 20,
                        ),
                      ),
                      const SizedBox(
                        width: 8.0,
                      ),
                      InkWell(
                        onTap: () {},
                        child: Container(
                          height: 45,
                          width: 45,
                          decoration: BoxDecoration(
                              color: kSecondaryColor,
                              borderRadius: BorderRadius.circular(10.0)),
                          child: ElevatedButton(
                              onPressed: () {setState(() {
                                if(counter < widget.shopDetail.soluong){
                                  counter++;
                                  thanhtien = dongia * counter;
                                }
                              });}, 
                              child: const Icon(Icons.add),
                            ),
                        ),
                      )
                    ],
                  ),
                  const SizedBox(
                    height: 25,
                  ),
                  MaterialButton(
                    shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(50.0)),
                    minWidth: double.infinity,
                    height: 40,
                    color: kPrimaryColor,
                    onPressed: () {},
                    child: const Text(
                      "Add to Cart",
                      style: TextStyle(
                        color: kWhiteColor,
                        fontSize: 18,
                      ),
                    ),
                  ),
                  const SizedBox(
                    height: 25,
                  ),
                  MaterialButton(
                    shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(50.0)),
                    minWidth: double.infinity,
                    height: 40,
                    color: kPrimaryColor,
                    onPressed: () async {
                      if(counter > 0){
                        final response = await http.post(Uri.parse('https://localhost:44313/Api/AddBill'),
                        headers: <String, String>{
                            'Content-Type': 'application/json; charset=UTF-8',
                          },
                          body: jsonEncode(<String, dynamic>{
                            'MaKH': 'KH3',
                            'MaSP' : widget.shopDetail.maSp,
                            'SL': counter,
                            'DonGia': widget.shopDetail.dongia,
                            'ThanhTien': thanhtien,
                          }),
                        );
                        if(response.statusCode == 200){
                          showDialog(
                            context: context, 
                            builder: (context) => AlertDialog(
                              title: const Text('Thông Báo'),
                              content: const Text('Mua Hàng thành công'),
                              actions: [
                                TextButton(
                                  onPressed: () => Navigator.pop(context,'Cancel'), 
                                  child: const Text('Cancel')
                                ),
                                TextButton(
                                  onPressed: () => Navigator.pop(context,'Ok'), 
                                  child: const Text('Ok')
                                ),
                              ],
                            )
                          );
                        }
                      }
                      else{
                        showDialog(
                          context: context, 
                          builder: (context) => AlertDialog(
                            title: const Text('Thông Báo'),
                            content: const Text('Số lượng vật phẩm mua không hợp lệ'),
                            actions: [
                              TextButton(
                                onPressed: () => Navigator.pop(context,'Cancel'), 
                                child: const Text('Cancel')
                              ),
                              TextButton(
                                onPressed: () => Navigator.pop(context,'Ok'), 
                                child: const Text('Ok')
                              ),
                            ],
                          )
                        );
                      }
                    },
                    child: const Text(
                      "Buy product",
                      style: TextStyle(
                        color: kWhiteColor,
                        fontSize: 18,
                      ),
                    ),
                  )
                ],
              ),
            ),
          ],
        ),
      )),
    );
  }
}
