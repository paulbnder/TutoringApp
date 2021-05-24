import React from 'react';
import { AntDesign } from '@expo/vector-icons';
import { StyleSheet, View } from 'react-native';
import { useTheme } from '@react-navigation/native';
import * as Haptics from 'expo-haptics';
import { Avatar, Text, Divider } from 'react-native-elements';





function TeacherDetailsScreen({ navigation, route }) {
    const { margin, colors } = useTheme();
    const { teacher } = route.params;


    const goBack = () => {
        navigation.goBack();
        Haptics.selectionAsync();
      };

    const styles = StyleSheet.create({
        closeIcon: {
            zIndex: 10,
            top: margin,
            right: margin,
            opacity: 0.75,
            color: colors.text,
            position: 'absolute',
          },
        container: {
            top: 40,
            alignItems: 'center',
            padding: 10
        }
    })

    return (
        <View >
            <AntDesign size={27} name="close" onPress={goBack} style={styles.closeIcon} />
            <View style={styles.container}>
                <Avatar
                    source={{
                        uri:teacher.profilePictureSource
                    }}
                    size = "xlarge"
                    rounded
                    >
                </Avatar>
                <Text h3>{teacher.name}</Text>
                <Divider style={{height: 2,     alignSelf: 'stretch', backgroundColor: "#e1e8ee"}} />
            </View>
        </View>
    );
}

export default TeacherDetailsScreen;