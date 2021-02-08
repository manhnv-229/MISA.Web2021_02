<template>
   <div class="paging-bar">
                <div class="paging-record-info">
                    Hiển thị <b>1-20/1000</b> Nhân viên
                </div>
                <div class="paging-option">
                    <div class="btn-select-page m-btn-firstpage" onclick="currentPage(1)"></div>
                    <div class="btn-select-page m-btn-prev-page" onclick="plusPages(-1)"></div>
                    <div class="m-btn-list-page">
                        <button class="btn-pagenumber btn-pagenumber-selected" onclick="currentPage(1)">1</button>
                        <button class="btn-pagenumber" onclick="currentPage(2)">2</button>
                        <button class="btn-pagenumber" onclick="currentPage(3)">3</button>
                        <button class="btn-pagenumber" onclick="currentPage(4)">4</button>
                    </div>
                    <div class="btn-select-page m-btn-next-page" onclick="plusPages(1)"></div>
                    <div class="btn-select-page m-btn-lastpage" onclick="currentPage(4)"></div>
                </div>
                <div class="paging-record-option">
                    <b>20</b> Nh/trang
                </div>
            </div>
</template>

<script>
export default {
    name:'EmployeePagingBar'
}
</script>

<style>
.filter-bar {
    width: 100%;
    display: flex;
    align-items: center;
    height: 40px;
}

   
    .filter-bar .filter-right {
        position: absolute;
        right: 16px;
    }
.panel-right .paging-bar{
    height:56px;
}

.paging-bar {
    border-top: 2px solid #bbbbbb;
    position: relative;
    display: flex;
    align-items: center;
    justify-content: center;
    padding: 0 16px;
    z-index:3;
}

    .paging-bar .paging-record-info {
        position: absolute;
        left: 16px;
    }

    .paging-bar .paging-record-option {
        position: absolute;
        right: 16px;
    }

    .paging-bar .paging-option button {
        outline: none;
        cursor: pointer;
    }

    .paging-bar .paging-option {
        display: flex;
    }

</style>