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
//v-bind指令，因为mustache语法不能作用到HTML特性上
var app3 = new Vue({
    el: "#app-3",
    data: {
        isButtonDisabled: true
    }
})
//js表达式支持
//{{number+1}}、{{ok?"YES":"NO"}}、{{ message.split('').reverse().join('') }}
//每个绑定只能包含一个表达式，不然不会生效
var app4 = new Vue({
    el: ".app-4",
    data: {
        id: 10
    }
})
//指令：带有v-前缀的特殊属性
//指令的职责：当表达式的值改变时，将其产生的连带影响，响应式的作用于DOM
//v-if、
//参数：一些响应指令能够接受一个“参数”，在指令名称后以冒号表示例如 v-bind
//<a v-bind:href="url"></a>
//<a v-on:click="doSomething">
