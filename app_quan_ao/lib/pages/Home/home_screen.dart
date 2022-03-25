import 'package:app_quan_ao/Network/GetList.dart';
import 'package:app_quan_ao/model/CChiTietSanPham.dart';
import 'package:flutter/material.dart';
import 'package:app_quan_ao/constant.dart';

import 'components/bottom_bar.dart';
import 'components/category_list.dart';
import 'components/custom_appbar.dart';
import 'components/enum.dart';
import 'components/shop_product.dart';

class HomeScreen extends StatefulWidget {
  const HomeScreen({Key? key}) : super(key: key);

  @override
  _HomeScreenState createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> {

  late List<ChiTietSanPham> list;
  @override
  void initState() {
    super.initState();
    GetList.fetchCTSP().then((datafromServer) {
       setState(() {
         list = datafromServer;
       });
     });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: kWhiteColor,
      bottomNavigationBar: const CustomBottomBar(
        selectMenu: MenuState.home,
      ),
      body: SafeArea(
        child: ListView(
          children: [
            //appbar
            CustomAppbar(),
            SizedBox(
              height: 20,
            ),
            CategoryCard(),
            Padding(
              padding: EdgeInsets.all(8.0),
              child: Text(
                "Quần áo bán chạy",
                style: TextStyle(fontSize: 19, fontWeight: FontWeight.bold),
              ),
            ),
            //now we create model of our app food products and we import all images
            ShopCard(CTSPs: list,),
          ],
        ),
      ),
    );
  }
}
