<template>
  <div class="custom-select" :tabindex="tabindex" @blur="open = false">
    <div class="selected isFocus" :class="{ open: open }" @click="open = !open">
      {{ selected }}
    </div>
    <div class="items" :class="{ selectHide: !open }">
      <div
        v-for="(option, i) of options"
        :key="i"
        :class="{iss:i == index}"
        @click="
          selected = option;
          open = false;
          $emit('input', option,$event);
          index = i;
        "
      
      >
        {{ option }}
      </div>
    </div>
    
  </div>
</template>

<script>
export default {
  props: {
    options: {
      type: Array,
      required: true,
    },
    default: {
      type: String,
      required: false,
      default: null,
    },
    tabindex: {
      type: Number,
      required: false,
      default: 0,
    },
  },
  data() {
    return {
      selected: this.default
        ? this.default
        : this.options.length > 0
        ? this.options[0]
        : null,
      open: false,
      index:-1,
      
    };
  },
  methods:{
    
  },
  mounted() {
    this.$emit("input", this.selected);
  },
};
</script>

<style scoped>
.iss{

  background-color:#019160 !important;
  color: white !important;
}
.custom-select {
  position: relative;
  width: 100%;
  outline: none;
  height: 40px;
  
}

.custom-select .selected {
  
  /* background-color:  -internal-light-dark(rgb(255, 255, 255), rgb(59, 59, 59));
  border-radius: 4px;
  border: 1px solid #bbbbbb;
  color:-internal-light-dark(black, white);
  padding: 10.6px 16px;
  cursor: pointer;
  user-select: none;
  text-align: left; */
  display: flex;
    align-items: center;
    background-color:white;
    border-radius: 4px;
    height: 38px;
    font-size: 13px;
    color: black;
    font-family: GoogleSans-Regular;

    outline: none;
    border: 1px solid #bbbbbb;
    cursor: pointer;
    padding-left: 16px;

}

.custom-select .selected.open {
  border: 1px solid #019160;
  border-radius: 4px;
}

.custom-select .selected:after {
  position: absolute;
  content: "";
  top: 18px;
  right: 1em;
  width: 0;
  height: 0;
  border: 5px solid transparent;
  border-color: black transparent transparent transparent;

}

.custom-select .items {
  color: black;
  overflow: hidden;
  position: absolute;
  background-color: #fff;
  left: 0;
  right: 0;
  top:45px;
  z-index: 20;
}

.custom-select .items div {
  color: black;
  cursor: pointer;
  padding-left: 36px;
  user-select: none;
  height: 40px;
  display: flex;
    align-items: center;
    background-color:white;
    border: none;
    outline: none;
    cursor: pointer;
    padding-left: 36px;
}

.custom-select .items div:hover {
  background-color: #E9EBEE;
}

.selectHide {
  display: none;
}


</style>