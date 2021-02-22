<template>
  <div id="app">
    <div class="menu">
      <div class="header-menu">
        <div class="menu-logo menu-img"></div>
        <div class="app-logo app-img"></div>
      </div>
      <div class="content-menu">
        <div class="choice-content">
          <div class="logo-choice-content overview-img"></div>
          <div><a href="#">Tổng quan</a></div>
        </div>
        <div class="choice-content">
          <div class="logo-choice-content cast-img"></div>
          <div><a href="#">Tiền mặt</a></div>
        </div>
        <div class="choice-content">
          <div class="logo-choice-content bank-cast-img"></div>
          <div><a href="#">Tiền gửi</a></div>
        </div>
        <div class="choice-content">
          <div class="logo-choice-content b-store-img"></div>
          <div><a href="#">Mua hàng</a></div>
        </div>
        <div class="choice-content">
          <div class="logo-choice-content s-store-img"></div>
          <div><a href="#">Bán hàng</a></div>
        </div>
        <div class="choice-content">
          <div class="logo-choice-content manage-bill-img"></div>
          <div><a href="#">Quản lý hóa đơn</a></div>
        </div>
        <div class="choice-content">
          <div class="logo-choice-content capacity-img"></div>
          <div><a href="#">Kho</a></div>
        </div>
        <div class="choice-content">
          <div class="logo-choice-content material-img"></div>
          <div><a href="#">Công cụ dụng cụ</a></div>
        </div>
        <div class="choice-content">
          <div class="logo-choice-content asset-img"></div>
          <div><a href="#">Tài sản cố định</a></div>
        </div>
        <div class="choice-content">
          <div class="logo-choice-content tax-img"></div>
          <div><a href="#">Thuế</a></div>
        </div>
        <div class="choice-content">
          <div class="logo-choice-content price-img"></div>
          <div><a href="#">Giá thành</a></div>
        </div>
        <div class="choice-content">
          <div class="logo-choice-content gatheration-img"></div>
          <div><a href="#">Tổng hợp</a></div>
        </div>
        <div class="choice-content">
          <div class="logo-choice-content budget-img"></div>
          <div><a href="#">Ngân sách</a></div>
        </div>
        <div class="choice-content">
          <div class="logo-choice-content reportation-img"></div>
          <div><a href="#">Báo cáo</a></div>
        </div>
        <div class="choice-content">
          <div class="logo-choice-content analysation-img"></div>
          <div><a href="#">Phân tích tài chính</a></div>
        </div>
      </div>
    </div>
    <div class="content">
      <div class="header-content">
        <select class="slc" style="font-family: 'notosans-semibold'">
          <option value="1">CÔNG TY TNHH NƯỚC UỐNG TINH KHIẾT SÀI GÒN</option>
        </select>
        <input
          type="text"
          class="searching-fea icon-ip searching-img"
          placeholder="Nhập từ khóa tìm kiếm"
        />
        <div class="general-fea more-img"></div>
        <div class="general-fea setting-img"></div>
        <div class="general-fea messenger-img"></div>
        <div class="general-fea support-img"></div>
        <div class="general-fea notify-img"></div>
        <div class="avatar default-avatar-img"></div>
        <select class="name-user slc">
          <option value="1">Nguyễn Quang Minh</option>
        </select>
      </div>
      <div class="main-content">
        <ContentPageEmployeee />
      </div>
    </div>
  </div>
</template>

<script>
import ContentPageEmployeee from "./components/ContentPage/ContentPageEmployeee.vue";
export default {
  name: "App",
  components: {
    ContentPageEmployeee,
  },
};
</script>

<style>
@import url("./css/main.css");

#app {
  height: 100%;
  width: 100%;
  display: flex;
}
/* menu */
.menu {
  width: 180px;
  height: 100%;
  background-color: #142739;
  color: black !important;
}

.menu .header-menu {
  height: 45px;
  width: 100%;
  display: flex;
  align-items: center;
}

.app-logo {
  width: 80px;
  height: 45px;
  background-position: center;
  background-size: contain;
  margin-left: 8px;
}

.menu-logo {
  width: 16px;
  height: 16px;
  margin-left: 25px;
}

.menu .content-menu {
  height: calc(100% - 45px);
  width: 100%;
}

.choice-content {
  width: 185px;
  height: 35px;
  display: flex;
  align-items: center;
  cursor: pointer;
}

.choice-content:hover {
  background-color: royalblue;
}

.choice-content .logo-choice-content {
  width: 25px;
  height: 25px;
  margin-left: 15px;
  margin-top: 8px;
  cursor: pointer;
}

.choice-content a {
  text-decoration: none !important;
  color: white !important;
  margin-left: 6px !important;
}

/* end menu */

/* content */
.content {
  height: 100%;
  width: calc(100% - 180px);
}

.content {
  height: 100%;
  width: calc(100% - 180px);
}

.content .header-content {
  height: 45px;
  width: 100%;
  display: flex;
  align-items: center;
  background-color: white;
}

@media screen and (max-width: 1920px){
    .searching-fea {
      margin-left: 50%;
      width: 140px;
      margin-right: 10px;
    }
}

@media screen and (max-width: 1820px){
    .searching-fea {
      margin-left: 37%;
      width: 140px;
      margin-right: 10px;
    }
}

.general-fea {
      width: 24px;
      height: 24px;
      margin-left: 8px;
      cursor: pointer;
    }


::-webkit-input-placeholder {
  font-style: italic;
  font-size: 10px;
}

.avatar {
  width: 25px;
  height: 25px;
  border-radius: 16px;
  background-color: #d9d9d9;
  margin-left: 12px;
  cursor: pointer;
}

.content .main-content {
  width: 100%;
  height: calc(100% - 45px);
}

/* end content */
</style>
