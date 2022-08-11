
function DeleteInfo(dataId, url)
{
    if (confirm('是否删除'))
    {
        $.post(url, { id: dataId }, function (result)
        {
            if (result)
            {
                alert("删除成功！");
                window.location.reload();
            }
        }, "json")     

    }
}