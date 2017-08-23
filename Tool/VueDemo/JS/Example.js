//构造器 使用类MVVM的模式，在构造时需要传入一个对象，如 数据，模板，挂载元素，方法，声明周期钩子
var vm = new Vue({});
//属性和方法
var data = { a: 1 };
var vm = new Vue({
    el: '#app',
    data: data
})
console.log(vm.a === data.a);
vm.a = 2;
console.log(data.a);
data.a = 3;
console.log(vm.a);
//实例生命周期 created updated destryed
var vm1 = new Vue({
    data: {
        a: 1
    },
    created: function () {
        console.log("a的值是：" + this.a)
    }
})