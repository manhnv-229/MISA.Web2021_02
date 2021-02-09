<template lang="">
    <div class="dialog__delete">
        <div class="dialog__modal"></div>
        <div class="container">
            <div class="container__header">
                <div class="header__title">CẢNH BÁO!</div>
                <div class="icon--x" @click="setDisplay(false)">X</div>
            </div>
            <div class="container__content">{{message}}</div>
            <div class="container__footer">
                <button class="button--second yes" @click="deleteEmployee()">Đồng ý</button>
                <button class="button--second no" @click="setDisplay(false)">Hủy</button>
            </div>
        </div>
    </div>
</template>
<script>
import axios from 'axios'

export default {
    data() {
        return {
            
        }
    },
    props: {
        setDisplay: Function,
        loadData: Function,
        id: String,
        message: String,
        name: String
    },
    methods: {
        deleteEmployee() {
            axios.delete('http://localhost:49779/api/' + this.name + 's/' + this.id)
                .then(() => {
                    this.loadData();
                    this.setDisplay(false);
                })
                .catch(res => {
                    console.log(res);
                })
        }
    },
}
</script>
<style scoped>
.dialog__delete {
    position: fixed;
    width: 100%;
    height: 100vh;
    top: 0;
    left: 0;
}

.dialog__delete .dialog__modal {
    position: fixed;
    width: 100%;
    height: 100%;
    top: 0;
    left: 0;
    background-color: #000000;
    opacity: 0.4;
}

.dialog__delete .container {
    position: absolute;
    width: 400px;
    height: auto;
    font-size: 15px;
    background-color: #ffffff;
    border-radius: 4px;
    left: calc((100% - 400px)/2);
    top: calc((100% - 200px)/2);
}

    .dialog__delete .container .container__header {
        height: 50px;
        background-color: #E5E5E5;
    }

        .dialog__delete .container .container__header .header__title {
            float: left;
            height: 100%;
            width: auto;
            font-size: 25px;
            line-height: 50px;
            margin-left: 15px;
        }

        .dialog__delete .container .container__header .icon--x{
            float: right;
            height: 35px;
            width: 35px;
            background-color: #ffffff;
            display: flex;
            justify-content: center;
            align-items: center;
            cursor: pointer;
        }

    .dialog__delete .container .container__content {
        width: calc(100% - 20px);
        padding: 10px 10px 20px 10px;
    }

    .dialog__delete .container .container__footer {
        width: 100%;
        height: 50px;
        display: flex;
        justify-content: center;
        align-items: center;
    }

        .dialog__delete .container .container__footer button{
            margin: 0 5px 0 5px;
        }
</style>