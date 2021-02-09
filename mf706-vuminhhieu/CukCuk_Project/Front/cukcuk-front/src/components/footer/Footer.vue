<template>
  <section class="h-container-between-center">
   
      <!-- control content -->      
          <div class="paging-record-info">
            Hiển thị <b>1-10/1000</b> Khách hàng
          </div>
          <div class="h-container-around-center">
            <div class="h-btn-select-page h-btn-firstpage"></div>
            <div class="h-btn-select-page h-btn-prev-page"></div>
            <div class="h-container">
              <button class="h-btn-pagenumber btn-pagenumber-selected">1</button>
              <button class="h-btn-pagenumber">2</button>
              <button class="h-btn-pagenumber">3</button>
              <button class="h-btn-pagenumber">4</button>
            </div>
            <div class="h-btn-select-page h-btn-next-page"></div>
            <div class="h-btn-select-page h-btn-lastpage"></div>
          </div>
          <div class="paging-record-option"><b>10</b> Khách hàng/trang</div>
        
  </section>
</template>

<script>
export default {
  name: "Header",
  props: {
    msg: String,
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
button {
        outline: none;
        cursor: pointer;
    }
button:focus{
    outline: 0;    
    box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075), 0 0 8px rgba(102, 175, 233, 0.6);
}
</style>
