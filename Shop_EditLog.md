#2014-07-29 超市项目修改 

#修改主要列表 
	1.Recipient(订单配送信息表）增加 DeliveryRate（配送费） int 字段

	alter table Recipient 
	add DeliveryRate int null 


	2.用户信息中，收货人没有性别名称的显示，如前端下单显示 刘畅女士，那么，后台也应该显示 刘畅女士
	3.商品查询，超市帐号，只显示单个超市的商品。
 