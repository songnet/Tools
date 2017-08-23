//Mustache语法 {{}}：http://www.cnblogs.com/DF-fzh/p/5979093.html
// v-once 只执行一次的插值，当数据改变时，插值处的内容不会改变
var vm = new Vue({
    el: "#app",
    data: {
        msg: "我是文本！"
    }
})
//v-html：双大括号将数据解释为纯文本，v-html择输出真正的HTML
//<div v-html="rawHtml"></div> rawHtml是data中的属性而不是固定值！！
var app2 = new Vue({
    el: "#app-1",
    data: {
        msg: "<h1>我是HTML！</h1>"
    }
})